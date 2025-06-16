namespace SettingPortal.ViewModels;

public class ApiResponse
{
	public bool IsSuccess => !Errors.Any();

	public IList<string> Errors { get; private init; } = new List<string>();

	public object Data { get; private init; } = null;

	public static ApiResponse Success(object data)
	{
		return new ApiResponse { Data = data };
	}

	public static ApiResponse Failure(params string[] errors)
	{
		return new ApiResponse
		{
			Errors = [..errors]
		};
	}
}