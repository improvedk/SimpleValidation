using System;

namespace SimpleValidation
{
	public static class Guard
	{
		public static Validator<T> Check<T>(Func<T> getValue)
		{
			return new Validator<T>(getValue);
		}

		public static Validator<T> Check<T>(T value)
		{
			return new Validator<T>(value);
		}
	}
}