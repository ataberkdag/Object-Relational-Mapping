from declaration import Kullanıcı, Base
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

engine = create_engine("sqlite:///Kullanıcılar.db")
Base.metadata.bind = engine

DBSession = sessionmaker(bind = engine)
session = DBSession()

kullanıcılar = session.query(Kullanıcı).all()
sayı = 0
for i in kullanıcılar:
    sayı+=1

print(sayı)
