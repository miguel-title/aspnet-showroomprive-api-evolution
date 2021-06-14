using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtomicAPI.Helpers
{
    public class HashMapping
    {
        public SortedList<string, string> GetSortedFields(SortedList<string, object> Dictionary)
        {
            var SortedFields = new SortedList<string, string>();

            foreach (KeyValuePair<string, object> item in Dictionary)
            {
                if (item.Value == null)
                {
                    SortedFields.Add(item.Key, "");
                }
                else
                {
                    #region For List
                    if (item.Value.GetType() == typeof(Object[]))//List
                    {
                        foreach (var entry in (dynamic)item.Value)
                        {
                            foreach (var subentry in (dynamic)entry)
                            {
                                if (subentry.Value == null)
                                {
                                    if (SortedFields.Keys.ToList().Contains(subentry.Key))
                                    {
                                        SortedFields[subentry.Key] += string.Empty;
                                    }
                                    else
                                    { SortedFields.Add(subentry.Key, string.Empty); }
                                }
                                else
                                {
                                    if (SortedFields.Keys.ToList().Contains(subentry.Key))
                                    {
                                        SortedFields[subentry.Key] += subentry.Value.ToString();
                                    }
                                    else
                                    { SortedFields.Add(subentry.Key, subentry.Value.ToString()); }
                                }
                            }
                        }
                        //as we have used dictionary so we cant use any list as it will popup about duplicate key error
                    }
                    #endregion

                    #region if Class
                    if (item.Value.GetType() == typeof(Dictionary<string, object>))//Class
                    {
                        try
                        {
                            foreach (var entry in (dynamic)item.Value)
                            {
                                if (entry.Value == null)
                                {
                                    SortedFields.Add(entry.Key, string.Empty);
                                }
                                else
                                {
                                    SortedFields.Add(entry.Key, entry.Value.ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                    }
                    #endregion

                    #region String
                    if (item.Value.GetType() == typeof(string) || item.Value.GetType() == typeof(int) || item.Value.GetType() == typeof(float) || item.Value.GetType() == typeof(double))
                    {
                        SortedFields.Add(item.Key, item.Value.ToString());
                    }
                    #endregion
                }
            }
            return SortedFields;
        }

    }
}