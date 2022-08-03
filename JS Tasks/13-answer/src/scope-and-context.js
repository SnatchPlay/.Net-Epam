class Fighter {
  #name;
  #damage;
  #hp;
  #strength;
  #agility;
  #wins=0;
  #loses=0;
  constructor(args){
    this.#name=args.name;
    this.#damage=args.damage;
    this.#hp=args.hp;
    this.#strength=args.strength;
    this.#agility=args.agility;
  }
  getName(){
    return this.#name;
  }
  getDamage(){
    return this.#damage;
  }
  getHealth(){
    return this.#hp;
  }
  getAgility(){
    return this.#agility;
  }
  getStrength(){
    return this.#strength;
  }
  getWins(){
    return this.#wins;
  }
  getLoses(){
    return this.#loses;
  }
  heal(num){
    this.#hp+=num;
  }
  dealDamage(num){
    this.#hp-=num;
    if(this.#hp<=0){
      this.#hp=0;
    }
  }
  addWin(){
    this.#wins+=1;
  }
  addLoss(){
    this.#loses+=1;
  }

  // add an implementation here
  attack (Defender){
    const isSuccessful= Math.floor(Math.random() * 101);
    if((Defender.getAgility()+Defender.getStrength())>isSuccessful){
      console.log(this.getName()+" attack missed")
    }
    else{
      Defender.dealDamage(this.getDamage());
      console.log(this.getName()+' makes '+ this.getDamage()+' damage to '+Defender.getName());
    }
  }
  logCombatHistory(){
    console.log('Name:'+this.getName()+',Wins:'+this.getWins()+',Losses:'+this.getLoses());
  }

}

const battle = function (fighter1, fighter2) {
  if (fighter1.getHealth() === 0 || fighter2.getHealth() === 0)
  {
    let dead = fighter2.getHealth() === 0 ? fighter2 : fighter1;
    console.log(`${dead.getName()} is dead`);
    return 0;
  }
 
  while ((fighter2.getHealth()>0)||(fighter1.getHealth()>0)) {
    fighter1.attack(fighter2);
    fighter2.attack(fighter1);
    if(fighter2.getHealth()==0){
      
      console.log(fighter2.getName+' is dead');
      return fighter2;
    }
    else if(fighter1.getHealth()==0){
      
      console.log(fighter1.getName+' is dead');
      return fighter1;
    }
  }

};

module.exports = { Fighter, battle};
