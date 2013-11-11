using System;

namespace SimpleValidation
{
	public class ValidationException : ArgumentException
	{
		public ValidationException(string msg) : base(msg)
		{ }
	}
}