﻿using Lucene.Net.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lucene.Net
{
    public static class SystemTypesHelpers
    {
        public static char[] toCharArray(this string str)
        {
            return str.ToCharArray();
        }

        public static string toString(this object obj)
        {
            return obj.ToString();
        }

        public static bool equals(this object obj1, object obj2)
        {
            return obj1.Equals(obj2);
        }

        public static StringBuilder append(this StringBuilder sb, long value)
        {
            sb.Append(value);
            return sb;
        }

        public static StringBuilder append(this StringBuilder sb, string value)
        {
            sb.Append(value);
            return sb;
        }

        public static sbyte[] getBytes(this string str, string encoding)
        {
            return (sbyte[])(Array)Encoding.GetEncoding(encoding).GetBytes(str);
        }

        public static byte[] getBytes(this string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        public static int size<T>(this ICollection<T> list)
        {
            return list.Count;
        }

        public static T[] clone<T>(this T[] e)
        {
            return (T[]) e.Clone();
        }

        public static void add<T>(this ISet<T> s, T item)
        {
            s.Add(item);
        }

        public static void addAll<T>(this ISet<T> s, IEnumerable<T> other)
        {
            s.AddAll(other);
        }

        public static bool contains<T>(this ISet<T> s, T item)
        {
            return s.Contains(item);
        }

        public static bool containsAll<T>(this ISet<T> s, IEnumerable<T> list)
        {
            return list.Any(s.Contains);
        }

        public static bool remove<T>(this ISet<T> s, T item)
        {
            return s.Remove(item);
        }

        public static bool removeAll<T>(this ISet<T> s, IEnumerable<T> list)
        {
            return s.removeAll(list);
        }

        public static void clear<T>(this ISet<T> s)
        {
            s.Clear();
        }

        public static void retainAll<T>(this ISet<T> s, ISet<T> other)
        {
            foreach (var e in s)
            {
                if (!other.Contains(e))
                    s.Remove(e);
            }
        }

        public static void printStackTrace(this Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }

        /// <summary>
        /// Locates resources in the same directory as this type
        /// </summary>
        public static Stream getResourceAsStream(this Type t, string name)
        {
            Assembly assembly = t.Assembly;
            string namespaceSegment = t.Namespace.Replace("Lucene.Net", string.Empty);
            string assemblyName = assembly.GetName().Name;
            string fullResourcePath = string.Concat(assemblyName, namespaceSegment, ".", name);
            return assembly.GetManifestResourceStream(fullResourcePath);
        }

        public static int read(this TextReader reader, char[] buffer)
        {
            int bytesRead = reader.Read(buffer, 0, buffer.Length - 1);
            // Convert the .NET 0 based bytes to the Java -1 behavior when reading is done.
            return bytesRead == 0 ? -1 : bytesRead;
        }

        public static string replaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }
}
