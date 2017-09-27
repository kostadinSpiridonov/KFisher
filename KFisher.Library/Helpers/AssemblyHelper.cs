using System;
using System.Reflection;

namespace KFisher.Library.Helpers
{
    public static class AssemblyHelper
    {
        public static Assembly GetAssemblyByTypeName(string typeName)
        {
            var type = Type.GetType(typeName);
            return type.Assembly;
        }
    }
}
