﻿using System.Text.RegularExpressions;

namespace SimpleValidation
{
	public class Validator<T>
	{
		internal T Value { get; private set; }
		internal string Name { get; private set; }

		public Validator(T value, string name)
		{
			Value = value;
			Name = name;
		}
	}

	public static class ValidatorExtensions
	{
		public static Validator<T> NotNull<T>(this Validator<T> validator)
		{
			if (validator.Value == null)
				throw new ValidationException("Parameter '" + validator.Name + "' must not be null.");

			return validator;
		}

		public static Validator<string> LengthBetween(this Validator<string> validator, int lower, int upper)
		{
			if (validator.Value.Length < lower || validator.Value.Length > upper)
				throw new ValidationException("Parameter '" + validator.Name + "' must be between " + lower + " and " + upper + " characters long.");

			return validator;
		}

		// Email regex from http://hexillion.com/samples/
		private static readonly Regex emailRegex = new Regex("^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public static Validator<string> Email(this Validator<string> validator)
		{
			if (!emailRegex.IsMatch(validator.Value))
				throw new ValidationException("Parameter '" + validator.Name + "' is not a valid email address.");

			return validator;
		}
	}
}