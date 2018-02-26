using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Task3Logic;

namespace Task3Tests
{
    [TestFixture]
    public class SetTests
    {
        public IEnumerable<TestCaseData> CalculateData
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3 })
                    .Returns(new Set<int>(new int[] { 1, 2, 3 }));
                yield return new TestCaseData(new int[] { 1, 2, 3, 3, 3, 3, 2, 3, 1 })
                    .Returns(new Set<int>(new int[] { 1, 2, 3 }));
            }
        }
        [Test, TestCaseSource(nameof(CalculateData))]
        public Set<int> Constructors_Test(IEnumerable<int> list)
        {
            return new Set<int>(list);
        }

        static void Main(string[] args)
        {
            Set<int> set = new Set<int> { 1, 2, 3 };
            Console.Write(set.Contains(1) + " ");
            HashSet<int> hash = new HashSet<int> { 1, 2, 3 };
            Console.WriteLine(hash.Contains(1));
            Console.WriteLine(set.Count + " " + hash.Count);
            set.Add(5);
            hash.Add(5);
            set.ExceptWith(new int[] { 2, 3 });
            hash.ExceptWith(new int[] { 2, 3 });
            Console.Write(string.Join(" ", set.ToArray()) + " | " + string.Join(" ", hash.ToArray()));
            set.IntersectWith(new int[] { 1, 2 });
            hash.IntersectWith(new int[] { 1, 2 });
            Console.WriteLine();
            Console.Write(string.Join(" ", set.ToArray()) + " | " + string.Join(" ", hash.ToArray()));
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                int val = rnd.Next(0, 10);
                set.Add(val);
                hash.Add(val);
            }
            Console.WriteLine();
            Console.WriteLine(new Set<int>().IsProperSubsetOf(new int[] { 1 }) + " " +
                new HashSet<int>().IsProperSubsetOf(new int[] { 1 }));
            Console.WriteLine(new Set<int> { 1 }.IsProperSubsetOf(new int[] { 1 }) + " " +
                new HashSet<int> { 1 }.IsProperSubsetOf(new int[] { 1 }));
            Console.WriteLine(new Set<int> { 1 }.IsProperSubsetOf(new int[] { 1, 2 }) + " " +
                new HashSet<int> { 1 }.IsProperSubsetOf(new int[] { 1, 2 }));
            Console.WriteLine(new Set<int> { 1, 2, 3 }.IsProperSubsetOf(new int[] { 1, 2, 3, 4, 5 }) + " " +
                new HashSet<int> { 1, 2, 3 }.IsProperSubsetOf(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(new Set<int> { 1, 2, 3 }.IsProperSubsetOf(new int[] { 1, 2, 4, 5 }) + " " +
                new HashSet<int> { 1, 2, 3 }.IsProperSubsetOf(new int[] { 1, 2, 4, 5 }));
            Console.WriteLine(new Set<int> { 1, 2, 3 }.IsProperSupersetOf(new int[] { 1, 2, 3, 4, 5 }) + " " +
                 new HashSet<int> { 1, 2, 3 }.IsProperSupersetOf(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsProperSupersetOf(new int[] { 1, 2, 3 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsProperSupersetOf(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsSubsetOf(new int[] { 1, 2, 3 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsSubsetOf(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsSubsetOf(new int[] { 1, 2, 3, 8, 9 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsSubsetOf(new int[] { 1, 2, 3, 8, 9 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsSupersetOf(new int[] { 1, 2, 3, 8, 9 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsSupersetOf(new int[] { 1, 2, 3, 8, 9 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.IsSupersetOf(new int[] { 1, 2, 3 }) + " " +
                  new HashSet<int> { 1, 2, 3, 8 }.IsSupersetOf(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 1, 2, 3, 8 }.Overlaps(new int[] { 1, 2, 3 }) + " " +
                 new HashSet<int> { 1, 2, 3, 8 }.Overlaps(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 0 }.Overlaps(new int[] { 1, 2, 3 }) + " " +
                 new HashSet<int> { 0 }.Overlaps(new int[] { 1, 2, 3 }));
            Console.WriteLine(new Set<int> { 1, 2, 3 }.SetEquals(new int[] { 2, 1, 3, 1 }) + " " +
                 new HashSet<int> { 1, 2, 3 }.SetEquals(new int[] { 2, 1, 3, 1 }));
            set.SymmetricExceptWith(new int[] { 1, 3 });
            hash.SymmetricExceptWith(new int[] { 1, 3 });
            Console.WriteLine(string.Join(" ", set) + " | " + string.Join(" ", hash));
            set.UnionWith(new int[] { 1, 2, 3, 4 });
            hash.UnionWith(new int[] { 1, 2, 3, 4 });
            Console.WriteLine(string.Join(" ", set) + " | " + string.Join(" ", hash));
            Console.ReadKey(true);
        }
    }
}
