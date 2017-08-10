select * from sys.tables
select * from Categories

select * from Transactions where narration like '%CITI FOOD CENTRE POS DEBIT%'
update Transactions set CategoryId = 1 where narration like '%CITI FOOD CENTRE POS DEBIT%'
select * from Transactions where narration like 'NWD%'
update Transactions set CategoryId = 5 where narration like 'NWD%'

select * from Transactions where narration like '%OLACABS%'
update Transactions set CategoryId = 2 where narration like '%OLACABS%'

select * from Transactions where narration like '%BILLDESK%'
update Transactions set CategoryId = 8 where narration like '%BILLDESK%'

select * from Transactions where narration like '%BANERJEE%'
update Transactions set CategoryId = 3 where narration like '%BANERJEE%'

select * from Transactions where narration like '%redbus%'
update Transactions set CategoryId = 2 where narration like '%redbus%'

select * from Transactions where narration like '%HINDUSTAN PETROL POS DEBIT%'
update Transactions set CategoryId = 2 where narration like '%HINDUSTAN PETROL POS DEBIT%'

select * from Transactions where narration like '%SALARY FOR THE MONTH OF%'
update Transactions set CategoryId = 9 where narration like '%SALARY FOR THE MONTH OF%'

select * from Transactions where narration like 'ATW%'
update Transactions set CategoryId = 5 where narration like 'ATW%'

select * from Transactions where narration like '%CREDIT INTEREST%'
update Transactions set CategoryId = 10 where narration like '%CREDIT INTEREST%'

select * from Transactions where narration like '%DROPS TOTAL%'
update Transactions set CategoryId = 11 where narration like '%DROPS TOTAL%'

--update Categories set CategoryName = 'Grocery' where id = 1
select * from Transactions where narration like '%CHOWDESHWARI RIC%'
update Transactions set CategoryId = 1 where narration like '%CHOWDESHWARI RIC%'

select * from Transactions where narration like 'EAW%'
update Transactions set CategoryId = 5 where narration like 'EAW%'

select * from Transactions where narration like '%HOUSEJOY%'
update Transactions set CategoryId = 3 where narration like '%HOUSEJOY%'

--update Categories set CategoryName = 'House Rent,Main' where id = 3

select * from Transactions where narration like '%LIFE STYLE%'
update Transactions set CategoryId = 1009 where narration like '%LIFE STYLE%'

select * from Transactions where narration like '%TECHTATASKY%'
update Transactions set CategoryId = 8 where narration like '%TECHTATASKY%'

--update Categories set CategoryName = 'MobileTVIntern' where id = 8

select * from Transactions where narration like '%ANJAPPAR%'
update Transactions set CategoryId = 11 where narration like '%ANJAPPAR%'




------------------
select * from Transactions where narration like '%IQARA%'
update Transactions set CategoryId = 8 where narration like '%IQARA%'

update Categories set CategoryName = 'Intst|Surg|Inv' where id = 10

select * from Transactions where narration like '%manipal%'
update Transactions set CategoryId = 1010 where narration like '%manipal%'


select * from Transactions where narration like '%FUEL SURCHG%' and DepositAmount = 0
update Transactions set CategoryId = 2 where narration like '%FUEL SURCHG%' and DepositAmount = 0

select * from Transactions where narration like '%BILLDKKARNATAKASTATE%' and DepositAmount = 0
update Transactions set CategoryId = 2 where narration like'%BILLDKKARNATAKASTATE%' and DepositAmount = 0

select * from Transactions where narration like '%SALARY%' and WithdrawalAmount = 0
update Transactions set CategoryId = 9 where  narration like '%SALARY%' and WithdrawalAmount = 0

-----------------------------

select * from Transactions where narration like '%REV FUEL SCHG%' and WithdrawalAmount = 0
update Transactions set CategoryId = 10 where  narration like '%REV FUEL SCHG%' and WithdrawalAmount = 0


select * from Transactions where narration like '%IRCTC_NEW%' and DepositAmount = 0
update Transactions set CategoryId = 2 where narration like '%IRCTC_NEW%' and DepositAmount = 0

select * from Transactions where narration like '%auto care%' and CategoryId is null and DepositAmount = 0
update Transactions set CategoryId = 2 where narration like '%auto care%' and CategoryId is null and DepositAmount = 0

select * from Transactions where narration like '%auto care%' and CategoryId is null and WithdrawalAmount = 0
update Transactions set CategoryId = 10 where narration like '%auto care%' and CategoryId is null and WithdrawalAmount = 0

select * from Transactions where narration like '%THE HEALING TOUC%'
update Transactions set CategoryId = 1010 where narration like '%THE HEALING TOUC%'

select * from Transactions where narration like '%wine%'
update Transactions set CategoryId = 11 where narration like '%wine%'

select * from Transactions where narration like '%CHINNAMMAL%' and DepositAmount = 0
update Transactions set CategoryId = 2 where narration like '%CHINNAMMAL%'  and DepositAmount = 0

select * from Transactions where narration like '%DOMINOS%' and DepositAmount = 0
update Transactions set CategoryId = 11 where narration like '%DOMINOS%' and DepositAmount = 0

select * from Transactions where narration like '%supe%' and DepositAmount = 0
update Transactions set CategoryId = 1 where  narration like '%supe%' and DepositAmount = 0

select * from Transactions where narration like '%aircel%' and DepositAmount = 0
update Transactions set CategoryId = 8 where narration like '%aircel%' and DepositAmount = 0

select * from Transactions where narration like '%ATHIKALATHU%' and DepositAmount = 0
update Transactions set CategoryId = 1009  where narration like '%ATHIKALATHU%' and DepositAmount = 0

select * from Transactions where narration like '%HOTEL UDUPI%' and DepositAmount = 0
update Transactions set CategoryId = 11  where narration like '%HOTEL UDUPI%' and DepositAmount = 0

select * from Transactions where narration like '%CCARELIANCEGENERAL%' and DepositAmount = 0

select * from Categories
select * from Transactions where CategoryId is null










	







--Transactions
--Categories