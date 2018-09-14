# NQuery

NQuery has an expressive API. it follows a clean naming convention, which is very similar to the SQL syntax.

By providing a level of abstraction, supported t-sql.

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
- Specifies that duplicate rows can appear in the result set.
```cs
//NQuery
var queryResult = Query.From<Customer>();
queryResult.ToString();

//T-SQL
select id, firstName, lastName
from customer
 
```
### Example 2:
- Specifies the columns to be returned by the query.
```cs
//NQuery
var queryResult = Query.From<Customer>().Select(a => new { a.Id, a.LastName });
queryResult.ToString();

//T-SQL
select id, lastName
from Customer
 ```
### Example 3:
- Indicates that only a specified first set or percent of rows will be returned from the query result set.
```cs
//NQuery
var queryResult = Query.From<Customer>().Select(a => new { a.Id }).Top(10);
queryResult.ToString();

//T-SQL
select top (10) id
from customer
```

### Example 4:
- Specifies the columns to be returned by the query.
- Indicates that only a specified first set or percent of rows will be returned from the query result set.
- Specifies that only unique rows can appear in the result set.
- Specifies the search condition for the rows returned by the query.
```cs
//NQuery
var queryResult = Query.From<Customer>()
                .Select(a => new { a.FirstName })
                .Where(a => a.Id == 1 && a.LastName == "Paul")
                .Distinct()
                .Top(10);
queryResult.ToString();

//T-SQL
select distinct top (10) firstName
from customer
where ((id='1') AND (lastName='Paul'))
 ```
  
### Example 5:
- Specifies the columns to be returned by the query.
- Indicates that only a specified first set or percent of rows will be returned from the query result set.
- Specifies that only unique rows can appear in the result set.
- Specifies the search condition for the rows returned by the query.
- Specifies a column or a non-aggregate calculation on a column. 
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
select distinct top (10) firstName
from customer
where ((id='1') AND (lastName='Paul'))
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
select distinct top (10) firstName
from customer
where ((id='1') AND (lastName='Paul'))
group by firstName
order by id


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
