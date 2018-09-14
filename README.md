# NQuery

NQuery has an expressive API. it follows a clean naming convention, which is very similar to the SQL syntax.

By providing a level of abstraction over the supported t-sql.

NQuery supports complex queries, such as nested conditions, selection from SubQuery, filtering over SubQueries, Conditional Statements and others. Currently it has built-in compilers for SqlServer.


## Quick Examples

Entity:
```cs
 [TableMap("customer")]
 public class Customer
 {
        [ColumnMap("id")]
        public string Id { get; set; }
        [ColumnMap("firstName")]
        public string FirstName { get; set; }
        [ColumnMap("lastName")]
        public string LastName { get; set; }
        [ColumnMap("age")]
        public string Age { get; set; }
 }

```
### Example 1:


```cs
//NQuery
var queryResult = Query.From<Customer>();
queryResult.ToString();

//T-SQL
select Id, FirstName, LastName
from Customer
 
```
### Example 2:

```cs
//NQuery
var queryResult = Query.From<Customer>().Select(a => new { a.Id, a.LastName });
queryResult.ToString();

//T-SQL
select I
d, LastName
from Customer
 ```
### Example 3:

```cs
//NQuery
var queryResult = Query.From<Customer>().Select(a => new { a.Id }).Top(10);
queryResult.ToString();

//T-SQL
select top (10) Id
from Customer
```

### Example 4:

```cs
//NQuery
var queryResult = Query.From<Customer>()
                .Select(a => new { a.FirstName })
                .Where(a => a.Id == 1 && a.LastName == "Paul")
                .Distinct()
                .Top(10);
queryResult.ToString();

//T-SQL
select distinct top (10) FirstName
from Customer
where ((Id='1') AND (LastName='Paul'))
 ```
  
### Example 5:

```cs
//NQuery
var queryResult = Query
                .From<Customer>()
                .Select(a => new { a.FirstName })
                .Where(a => a.Id == 1 && a.LastName == "Paul")
                .GroupBy(a => new { a.FirstName })
                .Distinct()
                .Top(10);
queryResult.ToString();
                
//T-SQL                
select distinct top (10) FirstName
from Customer
where ((Id='1') AND (LastName='Paul'))
order by FirstName
```

### Example 6:

```cs
//NQuery
var queryResult = Query
                .From<Customer>()
                .Select(a => new { a.FirstName })
                .Where(a => a.Id == 1 && a.LastName == "Paul")
                .GroupBy(a => new { a.FirstName })
                .OrderBy(a => new { a.Id })
                .Distinct()
                .Top(10);
queryResult.ToString();               

//T-SQL
select distinct top (10) FirstName
from Customer
where ((Id='1') AND (LastName='Paul'))
group by FirstName
order by Id


```
### Example 7:

```cs
//NQuery
var queryResult = Query.From<Customer>().Select(x => new { Id = Func.Sum(x.Id) });
queryResult.ToString();                

//T-SQL
select sum(id)
from customer
```
