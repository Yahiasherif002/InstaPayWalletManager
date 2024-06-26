# InstaPayWalletManager

A simple wallet management system using C# and Dapper. This application allows users to view, add, update, delete wallets, and perform balance transfers between wallets. It follows SOLID principles and demonstrates best practices for database interactions and transaction management.

## Features

- View all wallets
- View wallet by ID
- Add a new wallet
- Update an existing wallet
- Delete a wallet
- Transfer balance between wallets

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/InstaPayWalletManager.git
    cd InstaPayWalletManager
    ```

2. Set up the database:

    - Create a SQL Server database named `WalletDB`.
    - Execute the following SQL script to create the `Wallets` table:

        ```sql
        CREATE TABLE Wallets (
            Id INT PRIMARY KEY IDENTITY(1,1),
            Holder NVARCHAR(100),
            Balance DECIMAL(18, 2)
        );
        ```

3. Update the connection string in `appsettings.json`:

    ```json
    {
        "ConnectionStrings": {
            "DefaultConnection": "Server=your_server_name;Database=WalletDB;Trusted_Connection=True;"
        }
    }
    ```

4. Run the application:

    ```sh
    dotnet run
    ```

## Usage

Follow the prompts in the console to perform various operations:

1. View All Wallets
2. View Wallet by ID
3. Add Wallet
4. Update Wallet
5. Delete Wallet
6. Transfer Money
7. Exit

### Example

```sh
Choose an option:
1. View All Wallets
2. View Wallet by ID
3. Add Wallet
4. Update Wallet
5. Delete Wallet
6. Transfer Money
7. Exit




