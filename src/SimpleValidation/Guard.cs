namespace SimpleValidation
{
	public static class Guard
	{
		public static Validator<T> Check<T>(T value, string name)
		{
			return new Validator<T>(value, name);
		}
	}
}