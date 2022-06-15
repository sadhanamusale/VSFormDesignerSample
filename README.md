
# Sample form designer using VS extension

Provides a sample designer for form 

* Technologies: Visual Studio 2015 SDK
* Topics: Visual Studio Shell

**Description**

This sample demonstrates the following issues with form designer. 
The form has RTL property tru but in designer the scrollbar appears on right instead of left.



**Run the sample**

1.	Run the project in Visual Studio (as it is extension , cannot run by exe directly) , a new Visual Studio window will be opened.
2.	Inside the new Vs window click on File->Open File (Ctrl+o)
3.	Navigate to ‘TestTemplates’ path in project directory and select a template .
4.  See the form is opened in the designer. See the title is on Right and so is the scrollbar
5.  Expected result is : the form scrollbar should be on left as in VS 2010.


**Project Files**

 * **Test Form**  
 This file contains the form which is displayed in designer mode. Its RTL is true


**Related topics**

* [ Visual Studio SDK Documentation ](https://docs.microsoft.com/en-us/visualstudio/extensibility/visual-studio-sdk)



