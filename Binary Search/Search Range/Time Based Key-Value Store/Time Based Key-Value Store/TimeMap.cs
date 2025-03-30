namespace Time_Based_Key_Value_Store;

public class TimeMap
{
    // Init a time map with key as progressing timestamp and value is another map with values associated
    private Dictionary<string, List<(int timestamp, string value)>> timeMap;

    public TimeMap()
    {
        timeMap = new Dictionary<string, List<(int timestamp, string value)>>();
    }

    // TC: O(1)
    public void Set(string key, string value, int timestamp)
    {
        // If map doesn't contain the current key then add a new key with associated map timestamp value
        if (!timeMap.ContainsKey(key))
        {
            timeMap.Add(key, new List<(int timestamp, string value)>() { (timestamp, value) });
        }
        // If the current key  already exists then just add a new pair timestamp value to its map value
        else
        {
            timeMap[key].Add((timestamp, value));
        }
    }

    // TC: O(logn)
    public string GetBinarySearch(string key, int timestamp)
    {
        if (!timeMap.ContainsKey(key))
            return "";

        string recentValueKey = "";

        int left = 0;
        int right = timeMap[key].Count - 1;
        var listValuesTimeStamp = timeMap[key];

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // If mid is still in the lower bound behind timestamp
            // One of values from left to timestamp might be nearest so we update the any value in the range
            if (listValuesTimeStamp[mid].timestamp <= timestamp)
            {
                recentValueKey = listValuesTimeStamp[mid].value;
                left = mid + 1;
            }
            // If mid is in the higher bound than timestamp
            // Then move the right pointer behind mid to find the values that are close to timestamp
            else
            {
                right = mid - 1;
            }
        }

        return recentValueKey;
    }
}
