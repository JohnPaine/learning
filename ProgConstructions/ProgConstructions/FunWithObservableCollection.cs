using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgConstructions
{
    internal static class FunWithObservableCollection
    {
        /// <summary>
        /// Standard function for tests
        /// </summary>
        /// <exception cref="IOException">I/O exception occured. </exception>
        /// <exception cref="ArgumentOutOfRangeException">Parameter value <paramref name="index" /> is less 0.
        /// -or-Value <paramref name="index" /> is bigger than <see cref="P:System.Collections.ObjectModel.Collection`1.Count" />.</exception>
        public static void RunTests () {
            try {
                ObservableCollection<int> intCollection = new ObservableCollection<int> {1, 2, 3, 4, 5};

                intCollection.CollectionChanged += IntCollectionChanged;

                intCollection.Add (6);
                PrintCollection (intCollection);
                intCollection.Remove (3);
                PrintCollection (intCollection);
                intCollection.Move (0, 1);
                PrintCollection (intCollection);
                intCollection.Insert (4, 12);
                PrintCollection (intCollection);
                intCollection.RemoveAt (0);
                PrintCollection (intCollection);
            }
            catch (IOException e) {
                Console.WriteLine (e);
            }
        }

        private static void IntCollectionChanged (object sender,
                                                  System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {
            Console.WriteLine ("\nIntCollectionChanged, action: {0}", args.Action);

            if (args.NewItems != null)
                foreach (var newItem in args.NewItems) {
                    Console.WriteLine ("New item at {0} = {1}", args.NewItems.IndexOf (newItem), newItem);
                }
            if (args.OldItems != null)
                foreach (var oldItem in args.OldItems) {
                    Console.WriteLine ("Old item at {0} = {1}", args.OldItems.IndexOf (oldItem), oldItem);
                }
            Console.WriteLine ("New starting index - {0}", args.NewStartingIndex);
            Console.WriteLine ("Old starting index - {0}", args.OldStartingIndex);
            if (sender != null)
                Console.WriteLine ("\tSender type - {0}\n", sender.ToString ());
        }

        private static void PrintCollection<T> (IEnumerable<T> collection) {
            foreach (var variable in collection) {
                Console.WriteLine("\nVar = {0}", variable);
            }
        }
    }
}