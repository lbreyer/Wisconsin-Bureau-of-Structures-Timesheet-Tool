# Wisconsin-Bureau-of-Structures-Timesheet-Tool
The Bureau of Structures (BOS) in-house tool for querying employee timesheet data.


Project Description:

The WiBS Timesheet Tool is a simple application used by specific members of the Wisconsin Department of Transportation’s (WisDOT) Bureau of Structures for accessing and querying past timesheet data. Its primary functionality allows the user to pull timesheet data from a specific given month as stored through the authentication gateway. It displays the data in the primary screen and provides means for the user to sort and search the data as needed. Beyond this, it can export the queried, and potentially sorted, data to an excel file for external use or preservation.

This application is now used primarily as a reference tool. It provides a model for the authentication gateway access methodology beyond its simplified means of presenting timesheet data to the user. It also served as an early prototype for the MVC refactoring process which has since been expanded to larger BoS applications.

My Role:

My primarily responsibility on this project was to serve as the backend developer to use this application to both provide a standardized model for the authentication gateway accessing methodology and to prototype the refactoring process to MVC framework.

The goal of reorganizing the code structure in this update was to divide the concerns of the project into the MVC components. By doing this, we allow for simplification of simultaneous development through separation of components with the hope of improving scalability as we further expand the application's functionality going forward.

In addition to the refactoring, it was necessary for me to streamline and provide an effective model for the authentication gateway access. This process is used in many BoS applications for centralized file and resource access.

General Technical Information:

Project Type:
Windows Forms Application

Primarily Used Language(s):
C#

*Note: All code available is not intended for reuse but rather only as informative material. Any and all sensitive information contained in the solution including, but not limited to, security keys, authentication details, user information/data, and database or gateway logins necessary for normal function have been removed for the sake of security and privacy. 

Other Resources:
MVC Architecture Pdf and MVC Architecture Presentation included in repository.

If you have any further questions, please contact me at lukedbreyer@gmail.com or by any method found on the "About Me" page.
