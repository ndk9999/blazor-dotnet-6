namespace BoostMyTool.BlazorWeb.Models;

public class ApiResponse
{
	public bool Success { get; set; }

	public List<string> Errors { get; set; } = [];
}