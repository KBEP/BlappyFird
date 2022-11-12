using UnityEngine;

public struct FloatRange
{
	public readonly float min;
	public readonly float max;

	public FloatRange (float min, float max)
	{
		min = Numberize(min);
		max = Numberize(max);

		if (min > max)
		{
			// swap
			float tmp = min;
			min = max;
			max = tmp;
		}

		this.min = Mathf.Clamp(min, float.MinValue, float.MaxValue);
		this.max = Mathf.Clamp(max, float.MinValue, float.MaxValue);
	}

	public float GenRandom() => Random.Range(min, max);

	public bool Equals (FloatRange r) => min == r.min && max == r.max;

	public override string ToString () => $"FloatRange({min}, {max})";

	public override bool Equals (object obj) => obj is FloatRange r && Equals(r);

	public override int GetHashCode () => min.GetHashCode() ^ max.GetHashCode();

	public static bool operator == (FloatRange r1, FloatRange r2) => r1.Equals(r2);

	public static bool operator != (FloatRange r1, FloatRange r2) => !r1.Equals(r2);

	static float Numberize (float value)
	{
		if (float.IsNaN(value)) return 0.0f;
		if (float.IsNegativeInfinity(value)) return float.MinValue;
		if (float.IsPositiveInfinity(value)) return float.MaxValue;
		return value;
	}
}
