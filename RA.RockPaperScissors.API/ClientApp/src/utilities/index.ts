/**
 * This function takes an enum object as input and returns a random value from that enum.
 *
 * @param enumObj - An enum object.
 * @returns A random value from the enum object.
 */
export function getRandomValueFromEnum<T extends object>(enumObj: T): T[keyof T] {
  const keys = Object.keys(enumObj)
    .filter((key) => typeof enumObj[key as keyof typeof enumObj] === "number")
    .map((key) => key); // Get the keys of the enum object
  
  const randomIndex = Math.floor(Math.random() * keys.length); // Generate a random index

  const index = randomIndex === 0 ? 1 : randomIndex; // If the random index is 0, set it to 1

  return enumObj[keys[index] as keyof T]; // Return the value at the generated index from the enum object
}
