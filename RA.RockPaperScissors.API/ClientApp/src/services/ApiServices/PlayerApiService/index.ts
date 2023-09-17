import { getPlayerMatchUrl, getPlayerPatchUrl } from "../../../constants";
import { PlayerDto } from "../../../models";
import ApiService from "../ApiService";

export default class PlayerApiService extends ApiService<PlayerDto> {
  /* Public methods */
  public async getMatch(data: PlayerDto[]): Promise<PlayerDto> {
    const body = JSON.stringify(data);
    const response = await this.add(getPlayerMatchUrl(), body);

    return response;
  }

  public async patchPlayer(data: PlayerDto): Promise<PlayerDto> {
    const body = JSON.stringify(data);
    const response = await this.patch(getPlayerPatchUrl(data.id), body);

    return response;
  }
}
