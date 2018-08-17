using System;

namespace Kiss.Infrastructure.Testing
{
    public class TestHelper
    {
        public static T AssertThrows<T>(Action action)
           where T : Exception
        {
            return AssertThrows<T>(action, null, null);
        }

        public static T AssertThrows<T>(Action action, string expectedMessage, string errorMessage)
            where T : Exception
        {
            try
            {
                action.Invoke();
            }
            catch (T ex)
            {
                if (expectedMessage != null)
                {
                    // Assert.AreEqual(expectedMessage, ex.Message); // don't create dependency only because of one usage
                    if (expectedMessage != ex.Message)
                    {
                        throw new Exception(string.Format("Exception has been thrown, but message is wrong (expected '{0}', actual '{1}')", expectedMessage, ex.Message));
                    }
                }
                return ex;
            }
            throw new Exception(string.Format(errorMessage ?? "Exception of type {0} should be thrown.", typeof(T)));
        }

    }
}
