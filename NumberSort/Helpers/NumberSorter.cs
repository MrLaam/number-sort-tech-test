using NumberSort.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NumberSort.Views.Helpers
{
    public class NumberSorter
    {

        public NumberSet sortList(string unsortedList, string sortOrder)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            unsortedList = unsortedList.Trim().Replace(',', ' ');
            var strUnsortedList = unsortedList.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            int[] intUnsortedList = strUnsortedList.Select(int.Parse).ToArray();
            List<int> listUnsortedList = intUnsortedList.Cast<int>().ToList();

            listUnsortedList.Sort();
            if(sortOrder.Equals("Descending"))
            {
                listUnsortedList.Reverse();
            }

            stopWatch.Stop();

            NumberSet numberSet = new NumberSet();
            numberSet.SortedList = String.Join(",", listUnsortedList);
            numberSet.SortOrder = sortOrder;
            numberSet.SortTime = (Decimal)stopWatch.Elapsed.TotalMilliseconds;

            return numberSet;
        }

    }
}
