# Track And Trace Prototype
### What is this?
This is a a prototype for a track-and-trace system that will allow users to keep track of individuals with whom they have come into contact with and places that they have been.
Each user have a unique ID and phone number. The system will record events that are associated with each user. Events fall into two types
A contact occurs when two users have come into contact. Each contact records, the date and time of the contact and the two individuals involved.
A visit occurs when a user checks in at a particular location. Each visit record the user, the date time of the visit and the location.
The system also allows the creation of locations (shops, cafes etc).

### Features:
1.     Add a new individual.
2.     Add a new location
3.     Record the visit of an individual to a location
4.     Record a contact between two individuals
5.     Generate a list of all the telephone numbers of all individuals who have been contacts of a specified individual after a specified date and time
6.     Generate a list of telephone numbers of all individuals who visited a location between two dates and times

Users and locations are written to, and read from a .CSV file.

### How to use?
Just clone the repo and start it from the Trackandtrace1.sln file. You are required to have installed visual studio to run the .sln file. 
