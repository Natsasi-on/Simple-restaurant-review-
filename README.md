<h1 align="center">Restaurant Reviews Web - Explore and Edit Restaurant Information</h1>
<p align="center">
    Welcome to Restaurant Reviews Web, your platform to explore and edit restaurant information. Discover restaurants, view overviews, and make edits to keep the data up-to-date.
</p>

## Project Overview

This web application focuses on managing restaurant information through XML files and schema validation. The development process involves creating an XML document (`restaurant_reviews.xml`) for structured restaurant data, designing an XML Schema (`restaurant_review.xsd`) for validation, and building an ASP.NET MVC Core web application for validating XML files against their schema.

### XML Schema and Class Generation

Use `XSD.EXE` to generate classes from the XML schema (`restaurant_review.xsd`). The generated C# file (`restaurant_review.cs`) is placed in the `Data` folder of the ASP.NET MVC Core web application.

## ASP.NET MVC Core Web Application Functionality

1. **Restaurant Overview Page**
   - Display an overview of all restaurants from the `restaurant_review.xml` file.
   - Utilize a view model class for the overview.
   - Generate a view binding to a list of the above view model objects.
   - Create a list of `RestaurantOverviewViewModel` with data retrieved from `restaurant_review.xml`.
   - Pass the list as the model object when showing the view.

2. **Edit Restaurant Page**
   - Implement an "Edit" link for each restaurant, leading to a view for editing restaurant data.
   - Create an action method that takes the restaurant id as its parameter:
   - Create a view model for the edit view.
   - Generate a view binding to the view model with specific input field configurations.
   - Use a dropdown for the Province field, populated from an enum.

3. **Save Changes**
   - Implement a `[HttpPost]` annotated action method to handle the save operation.

## Getting Started

1. Clone the repository.
2. Open the solution in Visual Studio.

## License

This project is licensed under the Natsasion License. For detailed information, please refer to the [LICENSE](LICENSE) file.

## Contact

If you have any questions, feedback, or need assistance, please don't hesitate to reach out to us at [natsasion.sri@gmail.com](mailto:natsasion.sri@gmail.com).

Restaurant Reviews Web - Discover, Explore, and Keep Restaurant Data Updated!
