﻿// =======================================================================================
// Extensions
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Extensions
{
	
	// -----------------------------------------------------------------------------------
	// Converts any string into a hash
	// 64 bit safe and deterministic, generated values rarely change
	// truly unique hashes are not possible due to technical limitations
	// -----------------------------------------------------------------------------------
    public static int GetDeterministicHashCode(this string value)
    {
        unchecked {

            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            for (int i = 0; i < value.Length; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ value[i];
                if (i == value.Length - 1)
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ value[i + 1];
            }

            return hash1 + (hash2 * 1566083941);

        }
    }
    
	// -----------------------------------------------------------------------------------
	// Converts a float into a string and abbreviates it (e.g. 5m or 4d)
	// -----------------------------------------------------------------------------------
	public static string TimeFormat(this float seconds)
	{
	
		if (seconds >= 604800)
			return (seconds/604800).ToString("#,0W");
		
		if (seconds >= 86400)
			return (seconds/86400).ToString("0.#") + "D"; 
		
		if (seconds >= 3600)
			return (seconds/3600).ToString("#,0m");
			
		if (seconds >= 60)
			return (seconds/60).ToString("0.#") + "s";
		
		return seconds.ToString("#,0");
	
	}
	
	// -----------------------------------------------------------------------------------
	// Converts a long into a string and abbreviates it (e.g. 5M or 3K)
	// -----------------------------------------------------------------------------------
	public static string KiloFormat(this long num)
    {
        if (num >= 100000000)
            return (num/1000000).ToString("#,0M");

        if (num >= 10000000)
            return (num/1000000).ToString("0.#") + "M";

        if (num >= 100000)
            return (num/1000).ToString("#,0K");

        if (num >= 1000)
            return (num/1000).ToString("0.#") + "K";
		
        return num.ToString();
    } 
	
	// -----------------------------------------------------------------------------------
	// check if a list has duplicates
	// -----------------------------------------------------------------------------------
    public static bool HasDuplicates<T>(this List<T> list)
    {
        return list.Count != list.Distinct().Count();
    }
    
	// -----------------------------------------------------------------------------------
	// find all duplicates in a list
	// -----------------------------------------------------------------------------------
    public static List<U> FindDuplicates<T, U>(this List<T> list, Func<T, U> keySelector)
    {
        return list.GroupBy(keySelector)
                   .Where(group => group.Count() > 1)
                   .Select(group => group.Key).ToList();
    }
	
	// -----------------------------------------------------------------------------------
	
}

// =======================================================================================