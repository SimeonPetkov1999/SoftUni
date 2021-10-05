--22. All Mountain Peaks
select p.PeakName from Peaks p
order by p.PeakName

--23. Biggest Countries by Population
select top(30) c.CountryName,c.Population from Countries c
where c.ContinentCode = 'EU'
order by c.Population desc,c.CountryName

--24. Countries and Currency (Euro / Not Euro)
select c.CountryName,
c.CountryCode,
case	
	when c.CurrencyCode !='EUR' then 'Not Euro'
	else 'Euro'
end as [Currency]
from Countries c
order by c.CountryName

