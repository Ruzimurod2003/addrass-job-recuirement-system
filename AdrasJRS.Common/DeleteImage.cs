﻿namespace AdrasJRS.Common;
public class DeleteImage
{
    public static bool DeleteImageFile(string imagePath)
    {
        try
        {
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while deleting skill: {ex.Message}");
        }
        return false;
    }
}