using NUnit.Framework;

namespace SimpleValidation.Tests
{
	[TestFixture]
	public class GuardTests
	{
		[Test]
		public void NotNull()
		{
			Assert.DoesNotThrow(() => Guard.Check("test", "param").NotNull());
			Assert.Throws<ValidationException>(() => Guard.Check<string>(null, "param").NotNull());

			Assert.DoesNotThrow(() => Guard.Check(5, "param").NotNull());
			Assert.DoesNotThrow(() => Guard.Check((int?)5, "param").NotNull());
			Assert.DoesNotThrow(() => Guard.Check((int?)5, "param").NotNull());
			Assert.Throws<ValidationException>(() => Guard.Check<int?>(null, "param").NotNull());
			Assert.Throws<ValidationException>(() => Guard.Check((int?)null, "param").NotNull());
		}

		[Test]
		public void LengthBetween()
		{
			Assert.DoesNotThrow(() => Guard.Check("test", "param").LengthBetween(2, 6));
			Assert.DoesNotThrow(() => Guard.Check("test", "param").LengthBetween(4, 4));

			Assert.Throws<ValidationException>(() => Guard.Check("test", "param").LengthBetween(5, 6));
			Assert.Throws<ValidationException>(() => Guard.Check("test", "param").LengthBetween(1, 2));
			Assert.Throws<ValidationException>(() => Guard.Check("test", "param").LengthBetween(3, 3));
		}

		[Test]
		public void Email()
		{
			Assert.DoesNotThrow(() => Guard.Check("mark@improve.dk", "param").Email());
			Assert.DoesNotThrow(() => Guard.Check("markæøå@improve.dk", "param").Email());

			Assert.Throws<ValidationException>(() => Guard.Check("mark.@improve.dk", "param").Email());
			Assert.Throws<ValidationException>(() => Guard.Check("markimprove.dk", "param").Email());
			Assert.Throws<ValidationException>(() => Guard.Check("mark@@improve.dk", "param").Email());
			Assert.Throws<ValidationException>(() => Guard.Check("mark@improve..dk", "param").Email());
		}

		[Test]
		public void Positive()
		{
			Assert.DoesNotThrow(() => Guard.Check(1, "param").Positive());

			Assert.Throws<ValidationException>(() => Guard.Check(0, "param").Positive());
			Assert.Throws<ValidationException>(() => Guard.Check(-5, "param").Positive());
		}
	}
}