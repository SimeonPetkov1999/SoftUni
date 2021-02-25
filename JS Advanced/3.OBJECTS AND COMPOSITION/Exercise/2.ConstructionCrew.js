function solve(inputObj)
{
    if (inputObj.dizziness === true)
    {
        inputObj.levelOfHydrated += (inputObj.weight * 0.1) * inputObj.experience;
        inputObj.dizziness = false;
    }
    return inputObj;
}

console.log(solve({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
  ))