using System.Linq;
using System.Reflection;

namespace UnitTest
{
    public static class Common
    {
        public static T GetField<T>(object instance, string fieldName)
        {
            var fields = instance.GetType().GetFields(
                         BindingFlags.NonPublic |
                         BindingFlags.Instance |
                         BindingFlags.Public);

            return (T)fields.Where(x => x.Name == fieldName).First()
                .GetValue(instance);
        }
    }
}
