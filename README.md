# Recipe API

## Endpoints

### User Endpoints

- **[Get]** /api/allusers
> Returns a list of all users. Needs a valid JWT token to authorize.
- **[Get]** /api/user/{id}
> Returns the user with the specified ID.
- **[Post]** /api/user/register
> Create a new user, with a user object in post request body. Shape `{ UserID:0, UserName:string, Email:string, Password:string }`. ID is ignored and can be skipped.
- **[Post]** /api/login
> Returns a JWT that is valid for 1 hour, if the user/password, that is passed in the body, exists in the database. UserLoginDTO `{ UserName:string, Password:string }`
- **[Put]** /api/user/update
> Update a user. Requires a user object with the same ID as the JWT `{ UserID:0, UserName:string, Email:string, Password:string }`
- **[Delete]** /api/user/delete
> ***Warning*** **Deletes the user that sends its JWT. No confirmation or anything.**

### Recipe Endpoint

- **[Get]** /api/recipes
> Returns all the recipes.
- **[Get]** /api/recipe/{id}
> Returns the specified recipe from its ID.
- **[Get]** /api/recipe/search/{searchString}
> Returns a list based on the searchString input. Searches the Name of the recipes.
- **[Post]** /api/recipe/add
> Send a RecipeCreation-object in the body to add a recipe. Requires a valid JWT.
> `{ Name:string, Description:string, Ingredients:string, CategoryID:int }` userID is read from the JWT.
- **[Put]** /api/recipe/{recipeID}/update
> Updates the specified recipe(ID in the URL) using the same shape object as when creating a recipe. `{ Name:string, Description:string, Ingredients:string, CategoryID:int }`
> Requires a valid JWT from the same user that created the recipe.
- **[Delete]** /api/recipe/{recipeID}/delete
> Deletes specified recipe. Requires a valid JWT from the same user that created the recipe.

### Category Endpoint

- **[Get]** /api/categories
> Returns a list of all categories. `{ CategoryID:int, Name:string, Description:string }`
> Anonymous access allowed. Use to get the category ID for creating new recipes.

### Test Endpoint

- **[Get]** /test/get-my-claims
> Returns the userID and userRole from JWT claims.

## Other features

- Swagger + SwaggerUI, with Authorization for easy JWT use.
- JWT and an example in the testcontroller of how to get userID from the JWT
