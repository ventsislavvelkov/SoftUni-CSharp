ALTER TABLE Users
ADD CONSTRAINT UC_Username
CHECK (LEN(Username) >= 3)