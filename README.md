# Dapp.Api

Web API solution based Dapper MicroORM And Dapper infrastructure + UnitOfWork, Repository patterns

## Project structure

**1. Data Access layer (_Data/Infrastructure_, _Data/Repositories_)**

- UnitOfWork.cs
- ConnectionFactory.cs
- RepositoryBase.cs
- Repositories (DeviceRepository.cs)

**2. Services**

- DeviceService.cs

**3. API (Controllers)**

- DevicesController.cs

## Installation

1. Clone repository
2. Run UnitTests.
3. Run SQL scripts (`1-CreateDatabase.sql` then `2-InitDatabase.sql`) in `Data\Scripts` to create and initialize the database.
4. Build / Run.

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

## History

All changes can be easily found in [RELEASENOTES](ReleaseNotes.md)

## License

This project is licensed under the MIT License
