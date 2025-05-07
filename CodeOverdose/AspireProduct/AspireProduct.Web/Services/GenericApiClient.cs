using System.Text;
using System.Text.Json;
using AspireProduct.Core.Dtos;
using Newtonsoft.Json;

namespace AspireProduct.Web.Services;

public class GenericApiClient(HttpClient httpClient)
{
	public async Task<ApiResponse<TData>> GetAsync<TData>(string url)
	{
		try
		{
			return await httpClient.GetFromJsonAsync<ApiResponse<TData>>(url);
		}
		catch (Exception e)
		{
			return ApiResponse.Fail<TData>(e.Message);
		}
	}

	public async Task<ApiResponse<TData>> PostAsync<TPayload, TData>(string url, TPayload data)
	{
		try
		{
			var response = await httpClient.PostAsJsonAsync(url, data);
			var responseData = await response.Content.ReadAsStringAsync();
			
			return JsonConvert.DeserializeObject<ApiResponse<TData>>(responseData);
		}
		catch (Exception e)
		{
			return ApiResponse.Fail<TData>(e.Message);
		}
	}

	public async Task<ApiResponse<TData>> PutAsync<TPayload, TData>(string url, TPayload data)
	{
		try
		{
			var response = await httpClient.PutAsJsonAsync(url, data);
			var responseData = await response.Content.ReadAsStringAsync();
			
			return JsonConvert.DeserializeObject<ApiResponse<TData>>(responseData);
		}
		catch (Exception e)
		{
			return ApiResponse.Fail<TData>(e.Message);
		}
	}

	public async Task<ApiResponse<TData>> DeleteAsync<TData>(string url)
	{
		try
		{
			var response = await httpClient.DeleteAsync(url);
			var responseData = await response.Content.ReadAsStringAsync();

			return string.IsNullOrWhiteSpace(responseData)
				? ApiResponse.Ok<TData>(default)
				: JsonConvert.DeserializeObject<ApiResponse<TData>>(responseData);
		}
		catch (Exception e)
		{
			return ApiResponse.Fail<TData>(e.Message);
		}
	}
}
