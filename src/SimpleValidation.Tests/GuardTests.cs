using NUnit.Framework;

namespace SimpleValidation.Tests
{
	[TestFixture]
	public class GuardTests
	{
		[Test]
		public void NotNull()
		{
			Assert.DoesNotThrow(() => Guard.Check("test").NotNull());
			Assert.Throws<ValidationException>(() => Guard.Check((string)null).NotNull());

			Assert.DoesNotThrow(() => Guard.Check(5).NotNull());
			Assert.DoesNotThrow(() => Guard.Check((int?)5).NotNull());
			Assert.DoesNotThrow(() => Guard.Check((int?)5).NotNull());
			Assert.Throws<ValidationException>(() => Guard.Check((int?)null).NotNull());
		}

		[Test]
		public void LengthInclusiveBetween()
		{
			Assert.DoesNotThrow(() => Guard.Check("test").LengthInclusiveBetween(2, 6));
			Assert.DoesNotThrow(() => Guard.Check("test").LengthInclusiveBetween(4, 4));

			Assert.Throws<ValidationException>(() => Guard.Check("test").LengthInclusiveBetween(5, 6));
			Assert.Throws<ValidationException>(() => Guard.Check("test").LengthInclusiveBetween(1, 2));
			Assert.Throws<ValidationException>(() => Guard.Check("test").LengthInclusiveBetween(3, 3));
		}

		[Test]
		public void Email()
		{
			Assert.DoesNotThrow(() => Guard.Check("mark@improve.dk").Email());
			Assert.DoesNotThrow(() => Guard.Check("markæøå@improve.dk").Email());

			Assert.Throws<ValidationException>(() => Guard.Check("mark.@improve.dk").Email());
			Assert.Throws<ValidationException>(() => Guard.Check("markimprove.dk").Email());
			Assert.Throws<ValidationException>(() => Guard.Check("mark@@improve.dk").Email());
			Assert.Throws<ValidationException>(() => Guard.Check("mark@improve..dk").Email());
		}

		[Test]
		public void Positive()
		{
			Assert.DoesNotThrow(() => Guard.Check(1).Positive());

			Assert.Throws<ValidationException>(() => Guard.Check(0).Positive());
			Assert.Throws<ValidationException>(() => Guard.Check(-5).Positive());
		}

		[Test]
		public void Must()
		{
			Assert.DoesNotThrow(() => Guard.Check("x").Must(x => x.Length == 1, "No error"));

			Assert.Throws<ValidationException>(() => Guard.Check("x").Must(x => x.Length == 2, "Errro"));
		}

		[Test]
		public void InclusiveBetween()
		{
			Assert.DoesNotThrow(() => Guard.Check(5).InclusiveBetween(4, 6));
			Assert.DoesNotThrow(() => Guard.Check(5).InclusiveBetween(5, 6));
			Assert.DoesNotThrow(() => Guard.Check(5).InclusiveBetween(4, 5));
			Assert.DoesNotThrow(() => Guard.Check(5).InclusiveBetween(5, 5));

			Assert.Throws<ValidationException>(() => Guard.Check(5).InclusiveBetween(6, 7));
			Assert.Throws<ValidationException>(() => Guard.Check(5).InclusiveBetween(3, 4));
		}
	}
}