from declaration import Kullanıcı, Base
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

engine = create_engine("sqlite:///Kullanıcılar.db")
Base.metadata.bind = engine

DBSession = sessionmaker(bind = engine)

session = DBSession()
for i in range(1000):
    
    ahmet = Kullanıcı(Name = "Deneme", Surname = "Deneme")
    session.add(ahmet)

session.commit()
