# CI/CD Pipeline Documentation

This document describes the Continuous Integration and Continuous Deployment (CI/CD) setup for the Travel App with AI project.

## GitHub Actions Workflows

### Backend CI (`backend-ci.yml`)

This workflow handles the .NET backend application:

- **Trigger**: Runs on push to `main` branch and on pull requests targeting `main` that modify backend code
- **Jobs**:
  - `build`: Builds and tests the .NET solution
    - Restores NuGet dependencies
    - Builds the solution in Release mode
    - Runs unit tests

An integration test job is also included but commented out, to be enabled when MongoDB integration tests are implemented.

### Frontend CI (`frontend-ci.yml`)

This workflow handles the Next.js frontend application:

- **Trigger**: Runs on push to `main` branch and on pull requests targeting `main` that modify frontend code
- **Jobs**:
  - `build`: Builds and validates the frontend
    - Sets up Node.js environment
    - Installs dependencies using `npm ci`
    - Runs ESLint checks
    - Builds the Next.js application in production mode

Unit test step is commented out for now, to be enabled when tests are added.

## Development Workflow

The CI/CD pipeline supports the GitHub Flow workflow:

1. Create feature branches from `main`
2. Push changes to your feature branch
3. Open a pull request to `main`
4. CI workflows run automatically on the pull request
5. After passing checks and code review, the changes can be merged
6. CI workflows run again when changes are merged to `main`

## Future Enhancements

Planned enhancements for the CI/CD pipeline:

1. Add deployment workflows for different environments
2. Implement MongoDB integration tests
3. Configure frontend unit testing
4. Add code coverage reporting
5. Set up container builds for Docker deployment