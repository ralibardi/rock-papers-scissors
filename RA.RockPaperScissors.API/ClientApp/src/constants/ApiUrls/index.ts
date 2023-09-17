import { MatchPath, PlayerPath, LeaderboardPath, StartPath } from "../UrlConstants";

// Player API URLs
export function getPlayerMatchUrl(): string {
  // Use template literals instead of `concat` for string concatenation
  return `${PlayerPath}${MatchPath}`; // Output: "/Player/Match"
}

export function getPlayerPatchUrl(id: number): string {
  // Use template literals instead of `concat` for string concatenation
  return `${PlayerPath}/${id}`; // Output: "/Player/:id"
}

// Leaderboard API URLs
export function getStartGameUrl(): string {
  // Use template literals instead of `concat` for string concatenation
  return `${LeaderboardPath}${StartPath}`; // Output: "/Leaderboard/Start"
}

export function getLeaderboardUrl(): string {
  // Use template literals instead of `concat` for string concatenation
  return `${LeaderboardPath}`; // Output: "/Leaderboard"
}