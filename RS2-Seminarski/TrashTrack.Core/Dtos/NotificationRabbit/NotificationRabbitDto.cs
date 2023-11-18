﻿namespace TrashTrack.Core;

public class NotificationRabbitDto : BaseDto
{
	public string Title { get; set; } = null!;
	public string? Content { get; set; }
	public bool IsRead { get; set; } = false;

	public int UserId { get; set; }
	public UserDto User { get; set; } = null!;
}
