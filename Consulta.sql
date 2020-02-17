select p.Name, p.Email, pn.Phone, u.Code from People p 
inner join Unitys u on  u.Id = p.UnityId
inner join PhoneNumbers pn on pn.PersonId = p.Id
inner join Enterprices e on  e.Id = u.IdEnterprice
where e.Id = 1