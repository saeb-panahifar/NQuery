# NQuery

NQuery has an expressive API. it follows a clean naming convention, which is very similar to the SQL syntax.

By providing a level of abstraction over the supported t-sql.

NQuery supports complex queries, such as nested conditions, selection from SubQuery, filtering over SubQueries, Conditional Statements and others. Currently it has built-in compilers for SqlServer.


## Quick Examples
### Example 1:

```cs
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
    
var queryResult = Query.From<Customer>();
queryResult.ToString();


select Id, FirstName, LastName
from Customer
 
```
### Example 2:

```cs
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
    
var queryResult = Query.From<Customer>().Select(a => new { a.Id, a.LastName });

select Id, LastName
from Customer
 
```

### Example 3:

```cs
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
    
 var queryResult = Query.From<Customer>().Select(a => new { a.Id }).Top(10);

select top (10) Id
from Customer
 
```

### Example 4:

```cs
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
    
    var queryResult = Query.From<Customer>()
                .Select(a => new { a.FirstName })
                .Where(a => a.Id == 1 && a.LastName == "Paul")
                .Distinct()
                .Top(10);

select distinct top (10) FirstName
from Customer
where ((Id='1') AND (LastName='Paul'))
 
```
  
