using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManaging.Application.Exceptions
{
	public class StudentApplicationException : Exception
	{
		public StudentApplicationException()
		{
		}

		public StudentApplicationException(string message) : base(message)
		{
		}

		public StudentApplicationException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
