using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace SettingConsumer.Providers;

internal class JsonConfigurationParser
{
	private JsonConfigurationParser() { }

	private readonly Dictionary<string, string?> _data = new Dictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
	private readonly Stack<string> _paths = new Stack<string>();

	public static IDictionary<string, string> Parse(string appSettings)
	{
		using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(appSettings));
		return new JsonConfigurationParser().ParseStream(stream);
	}

	private Dictionary<string, string> ParseStream(Stream input)
	{
		var jsonDocumentOptions = new JsonDocumentOptions
		{
			CommentHandling = JsonCommentHandling.Skip,
			AllowTrailingCommas = true,
		};

		using (var reader = new StreamReader(input))
		using (var doc = JsonDocument.Parse(reader.ReadToEnd(), jsonDocumentOptions))
		{
			if (doc.RootElement.ValueKind != JsonValueKind.Object)
			{
				throw new FormatException($"Invalid Top Level JSON Element {doc.RootElement.ValueKind}");
			}

			VisitObjectElement(doc.RootElement);
		}

		return _data;
	}

	private void VisitObjectElement(JsonElement element)
	{
		var isEmpty = true;

		foreach (var property in element.EnumerateObject())
		{
			isEmpty = false;
			EnterContext(property.Name);
			VisitValue(property.Value);
			ExitContext();
		}

		SetNullIfElementIsEmpty(isEmpty);
	}

	private void VisitArrayElement(JsonElement element)
	{
		var index = 0;

		foreach (var arrayElement in element.EnumerateArray())
		{
			EnterContext(index.ToString());
			VisitValue(arrayElement);
			ExitContext();
			index++;
		}

		SetNullIfElementIsEmpty(isEmpty: index == 0);
	}

	private void SetNullIfElementIsEmpty(bool isEmpty)
	{
		if (isEmpty && _paths.Count > 0)
		{
			_data[_paths.Peek()] = null;
		}
	}

	private void VisitValue(JsonElement value)
	{
		switch (value.ValueKind)
		{
			case JsonValueKind.Object:
				VisitObjectElement(value);
				break;

			case JsonValueKind.Array:
				VisitArrayElement(value);
				break;

			case JsonValueKind.Number:
			case JsonValueKind.String:
			case JsonValueKind.True:
			case JsonValueKind.False:
			case JsonValueKind.Null:
				string key = _paths.Peek();
				if (_data.ContainsKey(key))
				{
					throw new FormatException($"Key '{key}' Is Duplicated");
				}
				_data[key] = value.ToString();
				break;

			default:
				throw new FormatException($"Unsupported JSON Token {value.ValueKind}");
		}
	}

	private void EnterContext(string context) =>
		_paths.Push(_paths.Count > 0 ? _paths.Peek() + ConfigurationPath.KeyDelimiter + context : context);

	private void ExitContext() => _paths.Pop();
}