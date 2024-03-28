# Recipe API

## Functional Endpoints

### User Endpoints

- /api/users
> Gets a list of all users. Needs a valid JWT token to authorize.
- /api/register
> Create a new user, with a user object in post request body. Shape `{ UserID:0, UserName:string, Email:string, Password:string }`. ID is optional.
- /api/login
> send a UserLoginDTO to login to the API and get a JWT to use for further requests. UserLoginDTO `{ UserName:string, Password:string }`

### Test Endpoints
- /test/categories
> Gets a list of all categories. `{ CategoryID:int, Name:string, Description:string, Recipes:{ListOfRecipes.} }`
> (Should probably make a DTO for this without the list of recipes)
- /test/get-my-claims
> Returns the userID and userRole from JWT claims. Just as an example of how to do it.

### Recipe Endpoint
- /api/recipe/add
> Send a RecipeCreationDTO in the body to add a recipe. Requires a valid JWT.
> `{ Name:string, Description:string, CategoryID:int }` userID is read from the JWT.
> Currently just returns the recipe.

## ToDo Endpoints

- Add recipe
- Update recipe
- Delete recipe
- Search for recipe (by title). List of results.
- Update user
- Delete user
- Give rating
Some more stuff? I don't remember.

## Other implemented features

- Swagger + SwaggerUI
- JWT and an example in the testcontroller of how to get userID from the JWT

#### Todo:

- Figure out all endpoints required.
