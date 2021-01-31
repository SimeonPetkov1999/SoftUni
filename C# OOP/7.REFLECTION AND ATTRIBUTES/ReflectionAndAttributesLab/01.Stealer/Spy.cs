using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _01.Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, params string[] fields)
        {

            Type typeOfClass = Type.GetType(nameOfClass);
            FieldInfo[] classFields = typeOfClass.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            Object createInstance = Activator.CreateInstance(typeOfClass, new object[] { });
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {typeOfClass.Name}");
            foreach (var item in classFields.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(createInstance)}");
            }
            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type typeOfClass = Type.GetType(className);
            var classFields = typeOfClass.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            var getPublicMethods = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var getNonPublicMethods = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var sb = new StringBuilder();
            foreach (var field in classFields)
            {

                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in getNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in getPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type typeOfClass = Type.GetType(className);
            var classPrivateMethods = typeOfClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            var sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {typeOfClass.Name}");
            sb.AppendLine($"Base Class: {typeOfClass.BaseType.Name}");
            foreach (var method in classPrivateMethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type typeOfClass = Type.GetType(className);
            var classGetMethods = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(m => m.Name.StartsWith("get"));
            var classSetMethods = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(m => m.Name.StartsWith("set"));

            var sb = new StringBuilder();

            foreach (var get in classGetMethods)
            {
                sb.AppendLine($"{get.Name} will return {get.ReturnType}");
            }

            foreach (var set in classSetMethods)
            {
                sb.AppendLine($"{set.Name} will set field of {set.GetParameters().First().ParameterType}");
            }
            return sb.ToString().Trim();
        }
    }
}
