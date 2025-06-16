namespace SettingConsumer.Models;

public class ApiResponse<T>
{
	public bool IsSuccess { get; set; }

	public IList<string> Errors { get; set; }

	public T Data { get; set; }
}