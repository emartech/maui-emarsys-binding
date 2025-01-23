namespace EmarsysBinding.Model;

public class EMSPredictFilter(string type, string field, string comparison, IList<string> expectations)
{

	public readonly string Type = type;
	public readonly string Field = field;
	public readonly string Comparison = comparison;
	public readonly IList<string> Expectations = expectations;

	public static EMSPredictFilter IncludeIsValue(string field, string value)
	{
		return new EMSPredictFilter("INCLUDE", field, "IS", [value]);
	}

	public static EMSPredictFilter IncludeInValues(string field, IList<string> values)
	{
		return new EMSPredictFilter("INCLUDE", field, "IN", values);
	}

	public static EMSPredictFilter IncludeHasValue(string field, string value)
	{
		return new EMSPredictFilter("INCLUDE", field, "HAS", [value]);
	}

	public static EMSPredictFilter IncludeOverlapsValues(string field, IList<string> values)
	{
		return new EMSPredictFilter("INCLUDE", field, "OVERLAPS", values);
	}

	public static EMSPredictFilter ExcludeIsValue(string field, string value)
	{
		return new EMSPredictFilter("EXCLUDE", field, "IS", [value]);
	}

	public static EMSPredictFilter ExcludeInValues(string field, IList<string> values)
	{
		return new EMSPredictFilter("EXCLUDE", field, "IN", values);
	}

	public static EMSPredictFilter ExcludeHasValue(string field, string value)
	{
		return new EMSPredictFilter("EXCLUDE", field, "HAS", [value]);
	}

	public static EMSPredictFilter ExcludeOverlapsValues(string field, IList<string> values)
	{
		return new EMSPredictFilter("EXCLUDE", field, "OVERLAPS", values);
	}

}
