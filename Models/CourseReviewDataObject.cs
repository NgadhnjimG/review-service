using System;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
public class CourseReviewDataObject
{
	public int CourseId { get; set; }
	public double StarReview { get; set; }
	public List<string> Comments { get; set; } = new List<string>();

	public CourseReviewDataObject()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
