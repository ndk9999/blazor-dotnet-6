﻿namespace SettingPortal.Models;

public abstract class BaseEntity
{
	/// <summary>
	/// Unique identifier for the computer (GUID).
	/// </summary>
	public string Id { get; set; }

	public bool IsActive { get; set; }

	public string CreatedBy { get; set; }

	public DateTime CreatedDate { get; set; }

	public string UpdatedBy { get; set; }
	
	public DateTime UpdatedDate { get; set; }
	
	public string Notes { get; set; }
}