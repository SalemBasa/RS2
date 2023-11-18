using AutoMapper;
using FluentValidation;

using TrashTrack.Core;
using TrashTrack.Shared.Services;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;
using System.Data;

namespace TrashTrack.Application
{
    public class UsersService : BaseService<User, UserDto, UserUpsertDto, UserSearchObject, IUsersRepository>, IUsersService
    {
        private readonly IValidator<UserChangePasswordDto> _passwordValidator;
        private readonly ICryptoService _cryptoService;

        public UsersService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<UserUpsertDto> validator, IValidator<UserChangePasswordDto> passwordValidator, ICryptoService cryptoService) : base(mapper, unitOfWork, validator)
        {
            _passwordValidator = passwordValidator;
            _cryptoService = cryptoService;
        }

        public async Task<UserSensitiveDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            var user = await CurrentRepository.GetByEmailAsync(email, cancellationToken);
            return Mapper.Map<UserSensitiveDto>(user);
        }

        public async Task ChangePasswordAsync(UserChangePasswordDto dto, CancellationToken cancellationToken)
        {
            await _passwordValidator.ValidateAsync(dto, cancellationToken);

            var user = await CurrentRepository.GetByIdAsync(dto.Id, cancellationToken);

            if (user == null)
                throw new UserNotFoundException();

            if (!_cryptoService.Verify(user.PasswordHash, user.PasswordSalt, dto.Password))
                throw new UserWrongCredentialsException();

            user.PasswordSalt = _cryptoService.GenerateSalt();
            user.PasswordHash = _cryptoService.GenerateHash(dto.NewPassword, user.PasswordSalt);

            CurrentRepository.Update(user);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public override async Task<UserDto> AddAsync(UserUpsertDto dto, CancellationToken cancellationToken = default)
        {
            await ValidateAsync(dto, cancellationToken);

            var entity = Mapper.Map<User>(dto);

            entity.PasswordSalt = _cryptoService.GenerateSalt();
            entity.PasswordHash = _cryptoService.GenerateHash(dto.Password!, entity.PasswordSalt);

            await CurrentRepository.AddAsync(entity, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);
            return Mapper.Map<UserDto>(entity);
        }

        public async Task ToggleStatusAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await CurrentRepository.GetByIdAsync(id, cancellationToken);
            if (user == null)
                throw new UserNotFoundException();

            user.IsActive = !user.IsActive;

            await UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> UpdateUserAsync(UserUpsertDto dto, CancellationToken cancellationToken = default)
        {
            var user = await CurrentRepository.GetByIdAsync(dto.Id.GetValueOrDefault(), cancellationToken);
            if (user == null)
                throw new UserNotFoundException();

            user.IsActive = dto.IsActive!.Value;
            user.IsVerified = dto.IsVerified!.Value;

            CurrentRepository.Update(user);
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            int combinedStatus = (user.IsActive ? 1 : 0) | (user.IsVerified ? 2 : 0);
            
            return combinedStatus;
        }

        public async Task<OverviewCountDto<int>> GetCountByRoleAsync(Role role, CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetCountByRoleAsync(role, cancellationToken);
            return new OverviewCountDto<int> { Count = count };
        }
        public override async Task<UserDto> UpdateAsync(UserUpsertDto dto, CancellationToken cancellationToken = default)
        {
            var user = await CurrentRepository.GetByIdAsync(dto.Id.Value, cancellationToken);
            if (user == null)
                throw new UserNotFoundException();

//            var existingProfileProductId = user.ProfileProductId;

            Mapper.Map(dto, user);

            if (!string.IsNullOrEmpty(dto.Password))
            {
                user.PasswordSalt = _cryptoService.GenerateSalt();
                user.PasswordHash = _cryptoService.GenerateHash(dto.Password, user.PasswordSalt);
            }
            
            CurrentRepository.Update(user);
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return Mapper.Map<UserDto>(user);
        }

        public async Task<int> GetUserCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetUserCountAsync(cancellationToken);
            return count;
        }

        public async Task<int> GetDriverCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetDriverCountAsync(cancellationToken);
            return count;
        }

        public async Task<int> GetAdministratorCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetAdministratorCountAsync(cancellationToken);
            return count;
        }
    }
}
