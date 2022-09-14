using CheckD.Domain.Command;
using CheckD.Domain.Model;
using CheckD.Domain.Queries;

namespace CheckD.WPF.Stores;

public class CheckListStore
{
	private readonly ICreateCheckListCommand _createCheckListCommand;
	private readonly IDeleteCheckListCommand _deleteCheckListCommand;
	private readonly IUpdateCheckListCommand _updateCheckListCommand;
	private readonly IGetAllCheckList _getAllCheckList;
	private readonly List<CheckListModel> _checkListModels;

	public IEnumerable<CheckListModel> checkListModels => _checkListModels;
	public event Action<CheckListModel> CheckListAdded;
	public event Action<CheckListModel> CheckListUpdated;
	public event Action<Guid> CheckListRemoved;
	public event Action CheckListLoaded;

	public CheckListStore(ICreateCheckListCommand createCheckListCommand
		, IDeleteCheckListCommand deleteCheckListCommand
		, IUpdateCheckListCommand updateCheckListCommand
		,IGetAllCheckList getAllCheckList)
	{
		_createCheckListCommand = createCheckListCommand;
		_deleteCheckListCommand = deleteCheckListCommand;
		_updateCheckListCommand = updateCheckListCommand;
		_getAllCheckList = getAllCheckList;
	}

	public async Task Load()
	{
		IEnumerable<CheckListModel> checkListModels = await _getAllCheckList.Execute();
		_checkListModels.Clear();
		_checkListModels.AddRange(checkListModels);
		CheckListLoaded?.Invoke();
	}
	public async Task Add(CheckListModel checkListModel)
	{
		await _createCheckListCommand.Execute(checkListModel);
		_checkListModels.Add(checkListModel);
		CheckListAdded?.Invoke(checkListModel);
	}
	public async Task Update(CheckListModel checkListModel)
	{
		_updateCheckListCommand.Execute(checkListModel);
		int currentIndex = _checkListModels.FindIndex(y => y.Id == checkListModel.Id);
		if (currentIndex != -1)
		{
			_checkListModels[currentIndex] = checkListModel;
		}
		else
		{
			_checkListModels.Add(checkListModel);
		}
		CheckListUpdated?.Invoke(checkListModel);
	}
	public async Task Delete(Guid id)
	{
		try
		{
			await _deleteCheckListCommand.Execute(id);
			_checkListModels.RemoveAll(x => x.Id == id);
			CheckListRemoved?.Invoke(id);
		}
		catch (Exception)
		{

			throw;
		}
	}
}
