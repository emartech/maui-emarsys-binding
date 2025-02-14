namespace EmarsysBinding.Model;

public class Filter(string type, string field, string comparison, IList<string> expectations)
{

	public readonly string Type = type;
	public readonly string Field = field;
	public readonly string Comparison = comparison;
	public readonly IList<string> Expectations = expectations;

	public static Filter IncludeIsValue(string field, string value)
	{
		return new Filter("INCLUDE", field, "IS", [value]);
	}

	public static Filter IncludeInValues(string field, IList<string> values)
	{
		return new Filter("INCLUDE", field, "IN", values);
	}

	public static Filter IncludeHasValue(string field, string value)
	{
		return new Filter("INCLUDE", field, "HAS", [value]);
	}

	public static Filter IncludeOverlapsValues(string field, IList<string> values)
	{
		return new Filter("INCLUDE", field, "OVERLAPS", values);
	}

	public static Filter ExcludeIsValue(string field, string value)
	{
		return new Filter("EXCLUDE", field, "IS", [value]);
	}

	public static Filter ExcludeInValues(string field, IList<string> values)
	{
		return new Filter("EXCLUDE", field, "IN", values);
	}

	public static Filter ExcludeHasValue(string field, string value)
	{
		return new Filter("EXCLUDE", field, "HAS", [value]);
	}

	public static Filter ExcludeOverlapsValues(string field, IList<string> values)
	{
		return new Filter("EXCLUDE", field, "OVERLAPS", values);
	}

}
