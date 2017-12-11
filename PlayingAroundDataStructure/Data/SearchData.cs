using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms
{
    class SearchData
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Try { get; set; }
        public int[] Data { get; set; }
        public int SearchNumber { get; set; }

        public SearchData(int size)
        {
            Data = new int[size];

            Low = 0;
            High = size - 1;

            for (int i = 0; i < size; i++)
            {
                Data[i] = i + 1;
            }
        }
    }

    class LinearSearch
    {
        //linear search complexity is O(n)

        private SearchData data = new SearchData(0);

        private bool _IsFound;
        public bool IsFound { get { return _IsFound; } }

        public int Try { get { return data.Try; } }

        public LinearSearch(int searchNumber, int arraySize)
        {
            data = new SearchData(arraySize);
            data.SearchNumber = searchNumber;

            DoSearch();
        }

        private void DoSearch()
        {
            data.Try = 0;
            _IsFound = false;

            for (int i = 0; i < data.Data.Length - 1; i++)
            {
                data.Try++;
                if (data.SearchNumber == data.Data[i])
                {
                    _IsFound = true;
                    break;
                }
            }
        }
    }

    class BinarySearch
    {
        //linear search complexity is O(log n)

        private SearchData data = new SearchData(0);

        private bool _IsFound;
        public bool IsFound { get { return _IsFound; } }

        public int Try { get { return data.Try; } }

        public BinarySearch(int searchNumber, int arraySize)
        {
            data = new SearchData(arraySize);
            data.SearchNumber = searchNumber;

            DoSearch();
        }

        private void DoSearch()
        {
            data.Try = 0;
            _IsFound = false;

            int mid = 0;

            while(!(_IsFound || data.Low > data.High))
            {
                mid = data.Low + ((data.High - data.Low) / 2);

                data.Try++;

                if (data.Data[mid] == data.SearchNumber)
                {
                    _IsFound = true;
                    break;
                }
                else if (data.Data[mid] > data.SearchNumber)
                {
                    data.High = mid - 1;
                }
                else if (data.Data[mid] < data.SearchNumber)
                {
                    data.Low = mid + 1; 
                }
            }            
        }
    }

    class InterpolationSearch
    {
        //linear search complexity is O(n)

        private SearchData data = new SearchData(0);

        private bool _IsFound;
        public bool IsFound { get { return _IsFound; } }

        public int Try { get { return data.Try; } }

        public InterpolationSearch(int searchNumber, int arraySize)
        {
            data = new SearchData(arraySize);
            data.SearchNumber = searchNumber;

            DoSearch();
        }

        private void DoSearch()
        {
            data.Try = 0;
            _IsFound = false;

            int mid = 0;

            while (!(_IsFound || data.Low > data.High))
            {
                mid = (data.Low + ((data.High - data.Low) / (data.Data[data.High] - data.Data[data.Low]))) *
                    (data.SearchNumber - data.Data[data.Low]);

                data.Try++;

                if (data.Data[mid] == data.SearchNumber)
                {
                    _IsFound = true;
                    break;
                }
                else if (data.Data[mid] > data.SearchNumber)
                {
                    data.High = mid - 1;
                }
                else if (data.Data[mid] < data.SearchNumber)
                {
                    data.Low = mid + 1;
                }
            }
        }
    }
}


