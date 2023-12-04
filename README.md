# ASPassignment2
I'm excited to introduce My ASP.NET aaaignment, which has several new and improved features and is made to efficiently manage and display records. Let's explore the most recent features and changes.



2. Improvements to the Model

By adding two new characteristics to my model, at least one of which is of the decimal type, I've increased its capabilities. Make sure to add these extra properties to the seed data file (SeedData.cs) for at least four rows.



3. Enhanced Search Capabilities

The "Index" page has been completely redesigned with advanced search functionality based on three requirements:

Date Filtering: This is now the main search parameter.
Implemented as the second search condition is string column filtering.
Applying decimal column filtering is the third search criterion.

To manage these search functionalities, a new controller method called "Search" has been implemented, along with a dynamic dropdown for search conditions.



4. Features with a checkbox and toggle

A handy checkbox is now provided for each record on the "Index" view. Additionally, I added a new button called "Hide Selected," which lets users change which records are visible at any given time. "Hidden," a new controller method, has been created to help with this.

5. The Page of Hidden Records
thrilling news! "Hidden," a new controller method, has been added to handle requests to access concealed records. These toggled records are displayed in a related view that can be accessed via a button or hyperlink in the "Index" view.


6. Capabilities for Deletion

Eliminate Every Hidden Record:

There's a new button on the hidden records page that says "Delete All." "DeleteAll," a controller method I've written, can handle requests to make all records visible.



Eliminate Every Record:

One more important addition! "DeleteAll," a new controller method, has been put into place to handle requests to remove every entry in the database. To easily remove every record, look for the "Delete All Records" button in the "Index" page.










